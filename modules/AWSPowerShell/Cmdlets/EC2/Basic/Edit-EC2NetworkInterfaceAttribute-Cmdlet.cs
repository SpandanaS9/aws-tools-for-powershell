/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the specified network interface attribute. You can specify only one attribute
    /// at a time. You can use this action to attach and detach security groups from an existing
    /// EC2 instance.
    /// </summary>
    [Cmdlet("Edit", "EC2NetworkInterfaceAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyNetworkInterfaceAttribute API operation.", Operation = new[] {"ModifyNetworkInterfaceAttribute"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyNetworkInterfaceAttributeResponse))]
    [AWSCmdletOutput("None or Amazon.EC2.Model.ModifyNetworkInterfaceAttributeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.EC2.Model.ModifyNetworkInterfaceAttributeResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2NetworkInterfaceAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Attachment_AttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the network interface attachment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Attachment_AttachmentId { get; set; }
        #endregion
        
        #region Parameter Attachment_DeleteOnTermination
        /// <summary>
        /// <para>
        /// <para>Indicates whether the network interface is deleted when the instance is terminated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Attachment_DeleteOnTermination { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Group
        /// <summary>
        /// <para>
        /// <para>Changes the security groups for the network interface. The new set of groups you specify
        /// replaces the current set. You must specify at least one group, even if it's just the
        /// default security group in the VPC. You must specify the ID of the security group,
        /// not the name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GroupId","Groups")]
        public System.String[] Group { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the network interface.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter SourceDestCheck
        /// <summary>
        /// <para>
        /// <para>Indicates whether source/destination checking is enabled. A value of <code>true</code>
        /// means checking is enabled, and <code>false</code> means checking is disabled. This
        /// value must be <code>false</code> for a NAT instance to perform NAT. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_NAT_Instance.html">NAT
        /// Instances</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SourceDestCheck { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyNetworkInterfaceAttributeResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NetworkInterfaceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NetworkInterfaceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NetworkInterfaceId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NetworkInterfaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2NetworkInterfaceAttribute (ModifyNetworkInterfaceAttribute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyNetworkInterfaceAttributeResponse, EditEC2NetworkInterfaceAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NetworkInterfaceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Attachment_AttachmentId = this.Attachment_AttachmentId;
            context.Attachment_DeleteOnTermination = this.Attachment_DeleteOnTermination;
            context.Description = this.Description;
            if (this.Group != null)
            {
                context.Group = new List<System.String>(this.Group);
            }
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            #if MODULAR
            if (this.NetworkInterfaceId == null && ParameterWasBound(nameof(this.NetworkInterfaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkInterfaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceDestCheck = this.SourceDestCheck;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.ModifyNetworkInterfaceAttributeRequest();
            
            
             // populate Attachment
            var requestAttachmentIsNull = true;
            request.Attachment = new Amazon.EC2.Model.NetworkInterfaceAttachmentChanges();
            System.String requestAttachment_attachment_AttachmentId = null;
            if (cmdletContext.Attachment_AttachmentId != null)
            {
                requestAttachment_attachment_AttachmentId = cmdletContext.Attachment_AttachmentId;
            }
            if (requestAttachment_attachment_AttachmentId != null)
            {
                request.Attachment.AttachmentId = requestAttachment_attachment_AttachmentId;
                requestAttachmentIsNull = false;
            }
            System.Boolean? requestAttachment_attachment_DeleteOnTermination = null;
            if (cmdletContext.Attachment_DeleteOnTermination != null)
            {
                requestAttachment_attachment_DeleteOnTermination = cmdletContext.Attachment_DeleteOnTermination.Value;
            }
            if (requestAttachment_attachment_DeleteOnTermination != null)
            {
                request.Attachment.DeleteOnTermination = requestAttachment_attachment_DeleteOnTermination.Value;
                requestAttachmentIsNull = false;
            }
             // determine if request.Attachment should be set to null
            if (requestAttachmentIsNull)
            {
                request.Attachment = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Group != null)
            {
                request.Groups = cmdletContext.Group;
            }
            if (cmdletContext.NetworkInterfaceId != null)
            {
                request.NetworkInterfaceId = cmdletContext.NetworkInterfaceId;
            }
            if (cmdletContext.SourceDestCheck != null)
            {
                request.SourceDestCheck = cmdletContext.SourceDestCheck.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.EC2.Model.ModifyNetworkInterfaceAttributeResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyNetworkInterfaceAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyNetworkInterfaceAttribute");
            try
            {
                #if DESKTOP
                return client.ModifyNetworkInterfaceAttribute(request);
                #elif CORECLR
                return client.ModifyNetworkInterfaceAttributeAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String Attachment_AttachmentId { get; set; }
            public System.Boolean? Attachment_DeleteOnTermination { get; set; }
            public System.String Description { get; set; }
            public List<System.String> Group { get; set; }
            public System.String NetworkInterfaceId { get; set; }
            public System.Boolean? SourceDestCheck { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyNetworkInterfaceAttributeResponse, EditEC2NetworkInterfaceAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
